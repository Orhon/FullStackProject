<template>
  <div class="c-calendar">
    <calendar-item v-for="ev in this.GetAllEvents" v-bind:key="ev.title" v-bind:item="ev"/>
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