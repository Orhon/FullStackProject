<template>
  <div class="c-calendar">
  
      <calendar-item v-for="ev in this.GetAllEvents" :key="ev.title" :event="ev" @click.native="showDetail(ev)"/> 
       
      <div class="c-detail" v-if="this.showHidden" v-bind:style="{'border-color': event.color}">
        <a href="#" class="close" @click="hideDetail()"></a>
        <h2 class="c-calendar-event__title"> {{event.title}}</h2>
        <p class="c-calendar-event__description">{{event.description}}</p>
        <h3 class="c-calendar-event__period">Location</h3>
        <p class="c-calendar-event__description">{{event.location}}</p>
        <h3 class="c-calendar-event__period">Date</h3>
        <p class="c-calendar-event__date">{{customFormatterDate(event.date)}}</p>
        <h3 class="c-calendar-event__period">Time</h3>
        <p class="c-calendar-event__description">{{event.time}}</p>
      </div>
  </div>
</template>

<script>

import CalendarItem from '../components/CalendarItem';
import CalendarDetail from '../components/CalendarDetail';
import moment from "moment";

export default {
  components:{
    CalendarItem,
    CalendarDetail
  },
  data(){
    return{
      showHidden: false,
      event:Object
      
    }
  },
  computed:{
      GetAllEvents () {
            return this.$store.getters.getsavedEvents
        }
  },
  methods:{
    showDetail: function(ev){
      this.event=ev;
      this.showHidden = true;

    },
    hideDetail: function(){
      this.showHidden = false;
    },
    customFormatterDate(date) {
      return moment(date).format("LL");
    }
  }
  
}
</script>



<style lang="scss" scoped>
@import '../style/components/components.calendar';
</style>