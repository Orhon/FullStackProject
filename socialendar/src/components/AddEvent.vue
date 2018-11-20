<template>
  <div>
    <h1>Add Event</h1>
    <form id="formEvent" action="#" @submit.prevent="addNewEvent">     
      
      <div>
        <label for="title">Event title</label>
        <input type="text" name="title" id="title" class="title-input" v-model="title">
      </div>

      <div>
        <label for="location">Location</label>
        <input type="text" name="location" id="location" class="location-input" v-model="location">
      </div>

      <div>
        <label for="description">Description</label>
        <textarea type="text" name="description" id="description" class="description-input" 
        v-model="description" form="formEvent"></textarea>
      </div> 

      <div class="pickDate">
        <datepicker placeholder="select date" 
        :inline="true" v-model="pickedDate" 
        :maximumView="'month'"
        :format="customFormatterDate"    
        >
        </datepicker>
        <h2>Date: {{customFormatterDate(pickedDate)}}</h2>
      </div>

      <div class="pickTime">
        <h2>Time: {{customFormatterTime(pickedTime)}}</h2>
        <vue-timepicker v-model="pickedTime" 
        format="HH:mm"
        :minute-interval="5"
        hide-clear-button
        class="noselect"
        ></vue-timepicker>       
      </div>
      <div>
        <label for="private">Private event?</label>
        <input type="checkbox" v-model="privateEvent">
      </div>
      <div>
        <button type="submit" class="btn-submit">Add Event</button>
      </div>   
        
    </form>

     
  </div>
</template>


<script>
import Datepicker from "vuejs-datepicker";
import VueTimepicker from "vue2-timepicker";
import moment from "moment";

export default {
  name: "addEvent",
  components: {
    Datepicker,
    VueTimepicker
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
      privateEvent: false
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
        privateEvent: this.privateEvent
      };
      console.log("added event: ", eventObj);
      localStorage.setItem("event", eventObj);
    },
    getCurrentTime: function() {
      this.pickedTime.HH = this.pickedDate.getHours();
      this.pickedTime.mm = this.pickedDate.getMinutes();
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
