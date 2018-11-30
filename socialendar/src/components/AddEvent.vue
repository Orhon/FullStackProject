<template>
  <div class="c-wrapper">
    <div class="c-headerTitle"><h1>{{$t("add_event")}}</h1></div>
    
    <form class="c-addevent__form" action="#" @submit.prevent="addNewEvent">     
      <div class="c-labels">

      <div class="c-addevent__input c-addevent__title">
        <label for="title">{{$t("event_title")}}:</label>
        <input type="text" name="title" id="title" placeholder="Title for your event" class="title-input" v-model="title">
      </div>

          <div class="c-addevent__input c-addevent__location">
            <label for="location">{{$t("location")}}:</label>
            <input placeholder="Location for your event" type="text" name="location" id="location" class="location-input" v-model="location">
          </div>

      <div class="c-addevent__input c-addevent__description">
        <label for="description">{{$t("description")}}:</label>
        <textarea placeholder="Short description of your event" type="text" name="description" id="description" class="description-input" 
        v-model="description" form="formEvent"></textarea>
      </div> 
      </div>
      <div class="pickTime c-addevent__timepicker">
        <h3>{{$t("time")}}: {{customFormatterTime(pickedTime)}}</h3>
        <vue-timepicker v-model="pickedTime" 
        format="HH:mm"
        :minute-interval="5"
        hide-clear-button
        class="noselect"
        ></vue-timepicker>       
      </div>



      <h3>{{$t("date")}}: {{customFormatterDate(pickedDate)}}</h3>
      <div class="pickDate c-addevent__datepicker">
        
        <datepicker placeholder="select date" 
        :inline="true" v-model="pickedDate" 
        :maximumView="'month'"
        :format="customFormatterDate"  
        :language="getLanguage()"  
        >
        </datepicker>
        
      </div>
            <div class="c-colorpicker">
        <h3>{{$t("color")}}</h3>
        <verte id="colorpicker" picker="square" v-model="color" model="hex" ></verte> 
      </div>
      


      <div>
        <button type="submit" class="c-btn-submit">{{$t("add_event")}}</button>
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
        //time: this.pickedTime,
        // privateEvent: this.privateEvent
      };
      this.$store.dispatch( 'AddEvent', eventObj)

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
@import "./src/style/components/components.addevent";
</style>
