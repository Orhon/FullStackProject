import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    token: localStorage.getItem("access_token") || null,
    user: JSON.parse(localStorage.getItem("user")) || null,
    savedEvents: (localStorage.getItem('savedEvents')) ? JSON.parse(localStorage.getItem('savedEvents')) : [],
  },
  getters: {
    loggedIn(state) {
      return state.token !== null;
    },
    getToken: state => state.token,
    getsavedEvents : state => state.savedEvents,
  },

  actions: {
    retrieveToken({context,dispatch}, credentials) {
      return new Promise((resolve, reject) => {
        axios
          // .post("/login", {
          .post("https://reqres.in/api/login", {
            username: credentials.username,
            password: credentials.password
          })
          .then(response => {
            dispatch('saveLogin',({context},response));
            resolve(response);
          })
          .catch(error => {
            console.log(error);
            reject(error);
          });
      });
    },
    register({context,dispatch}, data) {
      return new Promise((resolve, reject) => {
        axios
          .post("https://reqres.in/api/register", {
            name: data.name,
            email: data.email,
            password: data.password
          })
          .then(response => {
            dispatch('saveLogin',({context},response));
            resolve(response);
          })
          .catch(error => {
            reject(error);
          });
      });
    },
    saveLogin(context,response) {
      const token = response.data.token;
      const user = response.data.user;
      localStorage.setItem("access_token", token);
      //localStorage.setItem("user",JSON.stringify(user));
      context.commit("retrieveToken", token);
      //context.commit("setUser", user);
      
      console.log(response);
    },
    destroyToken(context) {
      // axios.defaults.headers.common['Authorization'] = 'Bearer ' + context.state.token

      if (context.getters.loggedIn) {
        localStorage.removeItem("access_token");
        context.commit("destroyToken");
      }
    },
    destroyUser(context) {
      // axios.defaults.headers.common['Authorization'] = 'Bearer ' + context.state.token

      if (context.getters.loggedIn) {
        localStorage.removeItem("user");
        context.commit("deleteUser");
      }
    },
    AddEvent(context,event ){
      context.commit("AddEvent",event)
    }
  },
  mutations: {
    retrieveToken(state, token) {
      state.token = token;
    },
    destroyToken(state) {
      state.token = null;
    },
    setUser(state, user) {
      state.user = user;
    },
    deleteUser(state, user) {
      state.user = null;
    },
    AddEvent(state,event){
      state.savedEvents.push(event)
      localStorage.setItem('savedEvents', JSON.stringify( state.savedEvents ));
  }
  }
});
