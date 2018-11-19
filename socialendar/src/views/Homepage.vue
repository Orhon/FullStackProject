<template>
  <div id="app">
    <div id="nav">
      <div><router-link to="/home">Home</router-link> |</div>
      <div><router-link to="/calendar">Calendar</router-link> |</div>
      <div v-if="!loggedIn"><router-link   to="/login">Login </router-link> |</div>
      <div  v-if="!loggedIn"><router-link  to="/register">Register</router-link> |</div>
      <div v-if="loggedIn"><router-link  to="/logout">Logout</router-link></div>  
   
    </div>
    <router-view/>



  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'home',
  components: {
    HelloWorld
  },
  computed: {
    loggedIn() {
      return this.$store.getters.loggedIn
    }
  }
}
</script>
