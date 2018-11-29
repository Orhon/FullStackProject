<template>
<<<<<<< HEAD
  <div class="c-calendar">
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
    <calendar-item/>
=======
  <div class="calendar">
    <h1>calendar here</h1>
    <add-event-page></add-event-page>
>>>>>>> 9cc757be5a9ae41563d1f97ec68b0e29bcd695bc
  </div>
</template>

<script>
import AddEventPage from "@/components/AddEvent.vue";

export default {
  name: "calendar",
  props: {
    msg: String
  },
  components:{
    AddEventPage
  }
  
}
</script>


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