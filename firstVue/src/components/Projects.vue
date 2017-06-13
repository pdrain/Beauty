<template>
  <div v-title="'项目'">
    <project-header></project-header>
    <project-list></project-list>
  </div>
</template>

<script>
import ProjectHeader from './projects/ProjectsHeader'
import ProjectList from './projects/ProjectsList'

export default {
  name: 'Projects',
  components: { ProjectHeader, ProjectList }
}
</script>

