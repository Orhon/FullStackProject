<template>
  <div id="app">
    <nav-header/>
    <router-view/>
    
  </div>
</template>

<script>  
// @ is an alias to /src
import NavHeader from '../components/NavHeader';


export default {
  name: 'home',
  components: {
    NavHeader
  },
  
}
</script>
