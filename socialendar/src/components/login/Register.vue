<template>
  <div class="login-form">
    <h2 class="login-heading">Register</h2>
    <form action="#" @submit.prevent="register">

      <div >
        <label for="name">Name</label>
        <input type="text" name="name" id="name" class="login-input" v-model="name" placeholder="name">
      </div>

      <div >
        <label for="email">Email</label>
        <input type="email" name="email" id="email" class="login-input" v-model="email" placeholder="email">
      </div>

      <div >
        <label for="password">Password</label>
        <input type="password" name="password" id="password" class="login-input" v-model="password" placeholder="password">
      </div>

      <div>
        <button type="submit" class="btn-submit">Create Account</button>
      </div>

    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: '',
      email: '',
      password: '',
    }
  },
  methods: {
    register() {
      this.$store.dispatch('register', {
        name: this.name,
        email: this.email,
        password: this.password,
      })
        .then(response => {
          this.$router.push({ name: 'home' })
        })
    }
  }
}
</script>
