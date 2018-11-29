<template>
  <div>
    <h1>{{$t("add_event")}}</h1>
    <form id="formEvent" action="#" @submit.prevent="addNewEvent">     
      
      <div>
        <label for="title">{{$t("event_title")}}</label>
        <input type="text" name="title" id="title" class="title-input" v-model="title">
      </div>

      <div>
        <label for="location">{{$t("location")}}</label>
        <input type="text" name="location" id="location" class="location-input" v-model="location">
      </div>

      <div>
        <label for="description">{{$t("description")}}</label>
        <textarea type="text" name="description" id="description" class="description-input" 
        v-model="description" form="formEvent"></textarea>
      </div> 

      <div class="pickDate">
        <datepicker placeholder="select date" 
        :inline="true" v-model="pickedDate" 
        :maximumView="'month'"
        :format="customFormatterDate"  
        :language="getLanguage()"  
        >
        </datepicker>
        <h2>{{$t("date")}}: {{customFormatterDate(pickedDate)}}</h2>
      </div>

      <div class="pickTime">
        <h2>{{$t("time")}}: {{customFormatterTime(pickedTime)}}</h2>
        <vue-timepicker v-model="pickedTime" 
        format="HH:mm"
        :minute-interval="5"
        hide-clear-button
        class="noselect"
        ></vue-timepicker>       
      </div>
      <div class="colorpicker">
        <h2>{{$t("color")}}</h2>
        <verte picker="square" v-model="color" model="hex" ></verte> 
      </div>
      <div>
        <label for="private">{{$t("private_event")}}</label>
        <input type="checkbox" v-model="privateEvent">
      </div>
      <div>
        <button type="submit" class="btn-submit">{{$t("add_event")}}</button>
      </div>   
        
    </form>

     
  </div>
</template>


<script>
import Datepicker from "vuejs-datepicker";
import VueTimepicker from "vue2-timepicker";
import moment from "moment";
import { en, nl } from "vuejs-datepicker/dist/locale";
import { i18n } from "@/plugins/i18n";
import Verte from 'verte';
import 'verte/dist/verte.css';

export default {
  name: "addEvent",
  components: {
    Datepicker,
    VueTimepicker,
    Verte
  },
  data() {
    return {
      format: "d MMMM yyyy",
      pickedDate: new Date(),
      pickedTime: {
        HH: "12",
        mm: "00",
        ss: "00"
      },
      location: "",
      description: "",
      title: "",
      user: null,
      color: '',
      privateEvent: false,
      lang: en
    };
  },
  computed: {},
  methods: {
    customFormatterDate(date) {
      //console.log(date)
      return moment(date).format("LL");
    },
    customFormatterTime(time) {
      //console.log(date)
      return `${time.HH}:${time.mm}`;
    },
    changeHandler() {},
    addNewEvent() {
      let eventObj = {
        location: this.location,
        title: this.title,
        description: this.description,
        user: this.user,
        date: this.pickedDate,
        time: this.pickedTime,
        privateEvent: this.privateEvent,
        color: this.color
      };
      console.log("added event: ", eventObj);
      localStorage.setItem("event", eventObj);
    },
    getCurrentTime: function() {
      this.pickedTime.HH = this.pickedDate.getHours();
      this.pickedTime.mm = this.pickedDate.getMinutes();
    },
    getLanguage: function() {
      let lang;
      i18n.locale == "en" ? (lang = en) : (lang = nl);
      return lang;
    }
  },
  created() {
    this.getCurrentTime();
  }
};
</script>

<style lang="scss" scoped>
@import "./src/style/components/components.addEvent";
</style>
