<template>
  <div class="c-register">
    <div class="c-register__form">

      <h2 class="c-register__header">Register</h2>
      <form action="#" @submit.prevent="register">

        <div class="form-control c-register-form__input">
          <input type="text" name="name" id="name" class="login-input" v-model="name" placeholder="name">
        </div>

        <div class="form-control c-register-form__input">
          <input type="email" name="email" id="email" class="login-input" v-model="email" placeholder="email">
        </div>

        <div class="form-control c-register-form__input">
          <input type="password" name="password" id="password" class="login-input" v-model="password" placeholder="password">
        </div>

        <div>
          <button type="submit" class="btn-submit c-register-form__register">Create Account</button>
        </div>

      </form>
    </div>
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


<style lang="scss" scoped>
@import '../../style/components/components.register';
</style>
