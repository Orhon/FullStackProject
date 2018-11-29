import Vue from "vue";
import Router from "vue-router";
import Home from './views/Home.vue';
import Dashboard from './views/Dashboard.vue';
import Events from './components/Calendar.vue';


Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "home",
      component: Dashboard,
    },
    {
      path:"/Dashboard/:Category",
      name:"dashboard",
      component: Dashboard,
              children: [
          {
            // UserProfile will be rendered inside User's <router-view>
            // when /user/:id/profile is matched
            path: 'Events',
            component: Events, Dashboard
          }]
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
