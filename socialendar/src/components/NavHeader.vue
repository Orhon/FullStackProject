<template>
    <ul class="c-nav">
      <div class="c-nav__listitem">
          <li class="c-nav__logo"><span class="c-nav__Boldlogo">Social</span>ender</li>
      </div>
      <div class="c-nav__listitem c-nav__links">
          <li class="c-nav__links__item" v-if="!loggedIn"><router-link to="/home">Home</router-link> </li>
          <li class="c-nav__links__item" v-if="!loggedIn"><router-link to="/login">Login </router-link> </li>
          <li class="c-nav__links__item" v-if="!loggedIn"><router-link to="/register">Register</router-link></li>
          <li class="c-nav__links__item" v-if="loggedIn"><router-link to="/logout">Logout</router-link></li>  
      </div>
    </ul>
</template>

<script>
export default {
    name:"NavHeader",
    computed: {
    loggedIn() {
      return this.$store.getters.loggedIn
    }
  }
}
</script>

<style lang="scss" scoped>
@import '../style/components/components.navigation';
</style>

