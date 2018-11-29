<template>
  <div class="c-calendar">
    <div v-for="ev in this.GetAllEvents" :key="ev.title">
      <calendar-item   :event="ev"/>
    </div>
    

  </div>
</template>

<script>

import CalendarItem from '../components/CalendarItem';
export default {
  components:{
    CalendarItem
  },
  created: function(){
      console.log(this.$store.getters.getsavedEvents)
  },
  computed:{
      GetAllEvents () {
            return this.$store.getters.getsavedEvents
            console.log(this.$store.getters.getsavedEvents)
        }
  },
  
}
</script>



<style lang="scss" scoped>
@import '../style/components/components.calendar';
</style>