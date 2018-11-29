<template>
  <div class="c-calendar">
      <calendar-item v-for="ev in this.GetAllEvents" :key="ev.title" :event="ev"/>
    

  </div>
</template>

<script>

import CalendarItem from '../components/CalendarItem';
export default {
  components:{
    CalendarItem
  },
  computed:{
      GetAllEvents () {
            return this.$store.getters.getsavedEvents
        }
  },
  
}
</script>



<style lang="scss" scoped>
@import '../style/components/components.calendar';
</style>