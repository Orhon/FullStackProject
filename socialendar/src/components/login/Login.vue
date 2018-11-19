<template>
  <div class="login-form">
    <h2 class="login-heading">Login</h2>
    <form action="#" @submit.prevent="login">
      <p>
        "email": "some@thing",
        "password": "123"
      </p><br>
      
      <div class="form-control">
        <label for="email">Username/Email</label>
        <input type="email" name="username" id="username" class="login-input" v-model="username">
      </div>

      <div class="form-control mb-more">
        <label for="password">Password</label>
        <input type="password" name="password" id="password" class="login-input" v-model="password">
      </div>

      <div class="form-control">
        <button type="submit" class="btn-submit">Login</button>
      </div>

    </form>
    <router-link to="/register" tag="button">Register</router-link>
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
        this.$router.push("/");
      });
    }
  }
};
</script>

