<template>
  <div class="c-calendar__event" v-bind:style="{'border-color': event.color}">
   <h2 class="c-calendar-event__title">{{event.title}}</h2>
    <p class="c-calendar-event__description">{{event.description}}</p>
    <h3 class="c-calendar-event__period">{{$t("location")}}</h3>
    <p class="c-calendar-event__description">{{event.location}}</p>
    <h3 class="c-calendar-event__period">{{$t("date")}}</h3>
    <p class="c-calendar-event__date">{{event.date}}</p>
  </div>
</template>


<style lang="scss" scoped>
@import "../style/components/components.calendarevent";
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
                color: String,
            }
    },
    // data:{
    //     styleObject:{ 
    //         border: 1px solid event.color       
    //     }
    // },
    created(){
        console.log("received event: ",this.event)
        //SetBorder();
    },
    // methods:{
    //     SetBorder : function(){
    //         card = document.getElementById("card");
    //         card.style.border = '1px solid {{event.color}}'

    //     }
    // }

}
</script>
