<template>
  <div class="calendar">
    <h1>calendar here</h1>
    <add-event-page></add-event-page>
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

