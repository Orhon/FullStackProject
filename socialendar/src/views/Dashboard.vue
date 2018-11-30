<template>
  <div class="o-grid">
    <!-- <dashboard-menu/> -->
    <div class="c-dashboard">
      <router-link to="/login">
        <button class="c-dashboard__navitem" v-if="!loggedIn">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 50 50" class="c-dashboard-navitem__svg">
            <path d="M 25 1 C 14.693688 1 5.9250828 7.5214964 2.53125 16.65625 A 1.0001 1.0001 0 1 0 4.40625 17.34375 C 7.5164172 8.9725036 15.536312 3 25 3 C 37.162603 3 47 12.837397 47 25 C 47 37.162603 37.162603 47 25 47 C 15.536312 47 7.5164172 41.027496 4.40625 32.65625 A 1.0001 1.0001 0 1 0 2.53125 33.34375 C 5.9250828 42.478504 14.693688 49 25 49 C 38.243397 49 49 38.243397 49 25 C 49 11.756603 38.243397 1 25 1 z M 25.90625 15.96875 A 1.0001 1.0001 0 0 0 25.78125 16 A 1.0001 1.0001 0 0 0 25.28125 17.71875 L 31.5625 24 L 2 24 A 1.0001 1.0001 0 0 0 1.90625 24 A 1.001098 1.001098 0 0 0 2 26 L 31.5625 26 L 25.28125 32.28125 A 1.016466 1.016466 0 1 0 26.71875 33.71875 L 34.71875 25.71875 A 1.0001 1.0001 0 0 0 34.71875 24.28125 L 26.71875 16.28125 A 1.0001 1.0001 0 0 0 25.90625 15.96875 z" overflow="visible" font-family="Sans"/>
          </svg>
        </button>
      </router-link>
      <button class="c-dashboard__navitem" v-bind:key="TabHome"
      v-on:click="currentTab = TabHome" :class="{currentTab:TabHome == active}">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" class="c-dashboard-navitem__svg">
          <path d="M 3 1 L 3 2 L 2.5 2 C 1.6774686 2 1 2.6774686 1 3.5 L 1 12.5 C 1 13.322531 1.6774686 14 2.5 14 L 12.5 14 C 13.322531 14 14 13.322531 14 12.5 L 14 3.5 C 14 2.6774686 13.322531 2 12.5 2 L 12 2 L 12 1 L 11 1 L 11 2 L 4 2 L 4 1 L 3 1 z M 2.5 3 L 3 3 L 3 4 L 4 4 L 4 3 L 11 3 L 11 4 L 12 4 L 12 3 L 12.5 3 C 12.781469 3 13 3.2185314 13 3.5 L 13 5 L 2 5 L 2 3.5 C 2 3.2185314 2.2185314 3 2.5 3 z M 2 6 L 13 6 L 13 12.5 C 13 12.781469 12.781469 13 12.5 13 L 2.5 13 C 2.2185314 13 2 12.781469 2 12.5 L 2 6 z M 5 7 L 5 8 L 6 8 L 6 7 L 5 7 z M 7 7 L 7 8 L 8 8 L 8 7 L 7 7 z M 9 7 L 9 8 L 10 8 L 10 7 L 9 7 z M 11 7 L 11 8 L 12 8 L 12 7 L 11 7 z M 3 9 L 3 10 L 4 10 L 4 9 L 3 9 z M 5 9 L 5 10 L 6 10 L 6 9 L 5 9 z M 7 9 L 7 10 L 8 10 L 8 9 L 7 9 z M 9 9 L 9 10 L 10 10 L 10 9 L 9 9 z M 11 9 L 11 10 L 12 10 L 12 9 L 11 9 z M 3 11 L 3 12 L 4 12 L 4 11 L 3 11 z M 5 11 L 5 12 L 6 12 L 6 11 L 5 11 z M 7 11 L 7 12 L 8 12 L 8 11 L 7 11 z"/>
        </svg>
      </button>
      <button class="c-dashboard__navitem" v-bind:key="TabEvent"
      v-on:click="currentTab = TabEvent" :class="{currentTab:TabEvent == active}" v-if="loggedIn">
        <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
        viewBox="0 0 16 16" style="enable-background:new 0 0 16 16;" xml:space="preserve" class="c-dashboard-navitem__svg">
          <path d="M3,1v1H2.5C1.7,2,1,2.7,1,3.5v9C1,13.3,1.7,14,2.5,14h10c0.8,0,1.5-0.7,1.5-1.5v-9C14,2.7,13.3,2,12.5,2H12V1h-1v1H4V1H3z
          M2.5,3H3v1h1V3h7v1h1V3h0.5C12.8,3,13,3.2,13,3.5V5H2V3.5C2,3.2,2.2,3,2.5,3z M2,6h11v6.5c0,0.3-0.2,0.5-0.5,0.5h-10
          C2.2,13,2,12.8,2,12.5V6z M8.1,11.5H6.9V7.2h1.3V11.5z M5.3,10V8.7h4.3V10H5.3z"/>
          <path class="st0" d="M2.7,6.6"/>
        </svg>
      </button>
      
      <div class="c-dashboard__navitem" v-if="loggedIn">
        <router-link to="/logout">
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" class="c-dashboard-navitem__svg">
              <path d="M 2.5 1 C 1.6774686 1 1 1.6774686 1 2.5 L 1 12.5 C 1 13.322531 1.6774686 14 2.5 14 L 12.5 14 C 13.322531 14 14 13.322531 14 12.5 L 14 12 L 14 11 L 14 10 L 13 11 L 13 12 L 13 12.5 C 13 12.781469 12.781469 13 12.5 13 L 2.5 13 C 2.2185314 13 2 12.781469 2 12.5 L 2 2.5 C 2 2.2185314 2.2185314 2 2.5 2 L 12.5 2 C 12.781469 2 13 2.2185314 13 2.5 L 13 4 L 14 5 L 14 3 L 14 2.5 C 14 1.6774686 13.322531 1 12.5 1 L 2.5 1 z M 10.728516 4.0214844 L 10.021484 4.7285156 L 12.292969 7 L 5 7 L 5 8 L 12.292969 8 L 10.021484 10.271484 L 10.728516 10.978516 L 14.207031 7.5 L 10.728516 4.0214844 z" font-weight="400" font-family="sans-serif" white-space="normal" overflow="visible"/>
          </svg>
        </router-link>
      </div>
      <div class="c-langSwitcher">
        <lang-switch></lang-switch>
      </div>
    </div>
    <div class="c-content">
        <component
          v-bind:is="currentTabComponent">
        </component>
    </div>
  </div>   
</template>

<script>

import Calendar from '../components/Calendar';
import AddEvent from '../components/AddEvent';
import LangSwitch from '../components/LanguageSwitcher';


export default {
  name:"dashboard",
  components:{
    Calendar,
    AddEvent,
    LangSwitch
  },
  data: function(){
    return{
        currentTab : 'Calendar',
        TabEvent : 'AddEvent',
        TabHome : 'Calendar',
    }
  },
    computed: {
    currentTabComponent: function () {
      return this.currentTab
      console.log(currentTab)
    },
    loggedIn() {
      return this.$store.getters.loggedIn;
    }
  }
}
</script>

<style lang="scss" scoped>
@import '../style/objects/objects.grid';
@import '../style/components/components.dashboard';
</style>


