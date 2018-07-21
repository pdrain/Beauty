<template>
  <div>
       <div class="title">{{articleinfo.title}}
                      <span class="date">03-09</span>
                  </div>
                  <div class="desc">{{articleinfo.description}}</div>
  </div>
</template>

<script>
export default {
  props:['articleinfo'],
  data() {
    return {};
  }
};
</script>
