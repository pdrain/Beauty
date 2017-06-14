<template>
  <div v-title="'美容项目'">
    <SearchBox></SearchBox>
     <div class="banner">
        <img src="../assets/banner-1.jpg" />
    </div>
    <project-header></project-header>
    <project-list></project-list>
  </div>
</template>

<script>
import SearchBox from './SearchBox';
import ProjectHeader from './projects/ProjectsHeader'
import ProjectList from './projects/ProjectsList'

export default {
  name: 'Projects',
  components: {SearchBox, ProjectHeader, ProjectList }
}
</script>

<style>
 .banner{width:100%; height:150px; background:#fff; border-top:1px #f0f0f0 solid; border-bottom:1px #f0f0f0 solid;}
 .banner img{width:100%; height:100%;}
</style>
