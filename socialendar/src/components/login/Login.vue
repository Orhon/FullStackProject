<template>
  <div class="c-login">
    <div class="c-login__form">
      <h2 class="c-login-form__header">Login</h2>
      <form action="#" @submit.prevent="login">
      <!-- <p>
        "email": "some@thing",
        "password": "123"
      </p><br>
       -->
      <div class="form-control c-login-form__input">
        <input type="email" name="username" id="username" class="login-input" v-model="username" placeholder="Username">
      </div>

      <div class="form-control mb-more c-login-form__input">
        <input type="password" name="password" id="password" class="login-input" v-model="password" placeholder="Password">
      </div>
      <div class="c-login-form__buttons">
        <button type="submit" class="btn-submit  c-login-form__login">Login</button>
        <router-link to="/register" tag="button" class="c-login-form__register">Register</router-link>
      </div>


    </form>

    </div>


  </div>
</template>

<script>
export default {
  name: "login",
  data() {
    return {
      username: "",
      password: ""
    };
  },
  methods: {
    
    login: function() {
      const { username, password } = this;
      this.$store.dispatch('retrieveToken', { username, password }).then(() => {
        this.$router.push({ name: 'home' });
      });
    }
  }
};
</script>


<style lang="scss" scoped>
@import '../../style/components/components.login';
</style>
