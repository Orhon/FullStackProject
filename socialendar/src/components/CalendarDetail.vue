<template>
  <div class="c-calendar">
      
  </div>
</template>

<script>

import CalendarItem from '../components/CalendarItem';
export default {
  name: "calendarDetail",
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
@import '../style/components/components.calendarDetail';
</style>