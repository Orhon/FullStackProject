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