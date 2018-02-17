<template>
  <div id="app">
    
    <div class="home">
      <div class="header">
        <page-header></page-header>
      </div>
      <div class="body">
        <div class="navi">
          <page-nav></page-nav>
        </div>
        <div class="content">
          <router-view></router-view>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import PageHeader from './components/Common/PageHeader'
import PageNav from './components/Common/PageNav'

export default {
  name: 'app',
  components: { PageHeader, PageNav },
  mounted() {

    document.querySelector('.body').style.height = (document.body.clientHeight - document.querySelector('.header').style.height) + 'px';
    
  }
}
</script>

<style>
@import './assets/css.css';
@import './assets/icons-css/font-awesome.min.css';

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100%;
}

.home {
  overflow: hidden;
  height: 100%;
}

.home .header {
  height: 80px;
  border-bottom: 1px #ccc solid;
}

.home .navi {
  width: 15%;
  height: 100%;
  float: left;
}

.home .content {
  width: 85%;
  float: left;
}
</style>
