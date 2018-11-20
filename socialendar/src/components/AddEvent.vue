<template>
  <div>
    <h1>Add Event</h1>
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
        class="noselect"
        ></vue-timepicker>       
      </div>
      <button>Add event</button>
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
        HH: "10",
        mm: "05",
        ss: "00"
      },
      location:'',
      description: '',
      eventName: '',
      username:''
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
      return `${time.HH}:${time.mm}`
    },
    changeHandler() {}
  }
};
</script>

<style lang="scss" scoped>
@import './src/style/components/components.addEvent'
</style>
