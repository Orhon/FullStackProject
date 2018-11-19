import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    token: localStorage.getItem("access_token") || null
  },
  getters: {
    loggedIn(state) {
      return state.token !== null;
    },
    getToken: state => state.token
  },

  actions: {
    retrieveToken(context, credentials) {
      return new Promise((resolve, reject) => {
        axios
          // .post("/login", {
          .post("https://reqres.in/api/login", {
            username: credentials.username,
            password: credentials.password
          })
          .then(response => {
            const token = response.data.token;

            localStorage.setItem("access_token", token);
            context.commit("retrieveToken", token);
            resolve(response);
            console.log(response);
          })
          .catch(error => {
            console.log(error);
            reject(error);
          });
      });
    },
    register(context, data) {
      return new Promise((resolve, reject) => {
        axios
          .post("https://reqres.in/api/register", {
            name: data.name,
            email: data.email,
            password: data.password
          })
          .then(response => {
            const token = response.data.token;
            context.commit("retrieveToken", token);
            console.log(response);
            resolve(response);
          })
          .catch(error => {
            reject(error);
          });
      });
    },
    destroyToken(context) {
      // axios.defaults.headers.common['Authorization'] = 'Bearer ' + context.state.token

      if (context.getters.loggedIn) {
        localStorage.removeItem("access_token");
        context.commit("destroyToken");
      }
    }
  },
  mutations: {
    retrieveToken(state, token) {
      state.token = token;
    },
    destroyToken(state) {
      state.token = null;
    }
  }
});
