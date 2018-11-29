<template>
  <div class="c-calendar__event">
   <h2 class="c-calendar-event__title">{{event.title}}</h2>
    <p class="c-calendar-event__description">{{event.description}}</p>
    <h3 class="c-calendar-event__period">Location</h3>
    <p class="c-calendar-event__description">{{event.location}}</p>
    <h3 class="c-calendar-event__period">Start</h3>
    <p class="c-calendar-event__date">{{event.date}}</p>
  </div>
</template>


<style lang="scss" scoped>
@import '../style/components/components.calendarevent';
</style>

<script>
export default {
    name: "CalendarItem",
    props:{
            event:{
                description: String,
                location: String,
                title: String,
                time: Object,
                date: String,
            }
    },
    created(){
        console.log("received event: ",this.event)
    }


}
</script>
