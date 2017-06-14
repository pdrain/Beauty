<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'app'
}
</script>

<style>
html{height: 100%;}
body{width: 100%;height: 100%; margin: auto;}
div,a,span,ul,li,dl,dd,h1,h2,h3,label,article,p,header,footer,hr{margin: 0px; padding: 0px}
li{list-style: none}
input[type='text'],input[type='password']{line-height:30px;text-indent: 5px;}
button{min-width: 60px;line-height: 25px;}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100%;
}
</style>
