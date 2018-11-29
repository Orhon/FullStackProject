<template>
  <div class="c-calendar">
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
  </div>
</template>



<script>

import CalendarItem from '../components/CalendarItem';
export default {
  components:{
    CalendarItem
  }
  
}
</script>



<style lang="scss" scoped>
@import '../style/components/components.calendar';
</style>