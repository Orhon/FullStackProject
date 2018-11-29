<template>
  <div class="c-calendar__event">
   <!-- <h2 class="c-calendar-event__title">{{event.title}}</h2> -->
    <p class="c-calendar-event__description">{{event.description}}</p>
    <h3 class="c-calendar-event__period">Start</h3>
    <!-- <p class="c-calendar-event__date">{{c.date}}</p> -->
  </div>
</template>


<style lang="scss" scoped>
@import '../style/components/components.calendarevent';
</style>

<script>
export default {
    props:{
            event:{
                type: Object,
            }
        },
}
</script>
