import Vue from "vue";
import Router from "vue-router";

Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/home",
      name: "home",
      component: () =>
        import(/* webpackChunkName: "home" */ "./components/HelloWorld.vue"),
    },
    {
      path: "/calendar",
      name: "calendar",
      component: () =>
        import(/* webpackChunkName: "calendar" */ "./components/Calendar.vue"),
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: () =>
        import(/* webpackChunkName: "login" */ "./components/login/Login.vue"),
      meta: {
        requiresVisitor: true
      }
    },
    {
      path: "/register",
      name: "register",
      component: () =>
        import(/* webpackChunkName: "register" */ "./components/login/Register.vue"),
      meta: {
        requiresVisitor: true
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: () =>
        import(/* webpackChunkName: "logout" */ "./components/login/Logout.vue")
    }
  ]
});
