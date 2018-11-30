<template>
  <div class="c-calendar">
    {{this.event}}
  </div>
</template>

<script>

import Dashboard from '../views/Dashboard.vue';
export default {
  name: "calendarDetail",
  components:{
      Dashboard
  },
  data(){
    return{
      event:this.$router.params.event
    }
  },
  computed:{
      
  },  
}
</script>



<style lang="scss" scoped>
@import '../style/components/components.calendarDetail';
</style>