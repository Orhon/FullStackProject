<template>
  <div id="app">
      <navigation/>
  </div>
</template>

<script>  
// @ is an alias to /src

import Navigation from '@/components/NavHeader';

export default {
  name: 'home',
  components: {
      Navigation
  },
  
}
</script>
