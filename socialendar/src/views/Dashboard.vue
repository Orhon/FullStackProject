<template>
  <div class="o-grid">
    <dashboard-menu/>
    <div class="c-content">
       <calendar/>
    </div>
  </div>   
</template>

<script>


import DashboardMenu from '../components/DashboardMenu';
import Calendar from '../components/Calendar';


export default {
  name:"Dashboard",
  components:{
    DashboardMenu,
    Calendar
  }
}
</script>

<style lang="scss" scoped>
@import '../style/objects/objects.grid';
</style>


