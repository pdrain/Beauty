<template>
  <div class="hospital-detail">
      <img src alt=""/>
      <section class="hospital-detail-header">
        <h1>深圳XXX医疗美容机构</h1>
        <dl>
          <dd>美丽效果：</dd>
          <dd>服务登记：</dd>
        </dl>
      </section>
       <section class="hospital-detail-baseinfo">
         <h2>机构简介</h2>
         <p></p>
       </section>
       <section class="hospital-detail-doctor">
         <h2>医师阵容</h2>
         <dl>
           <dd>
             <img src="" alt="">
             <div>
                <span>职称：</span>
                <span>经验：</span>
                <span>简介：</span>
             </div>
           </dd>
           <dd>
             <img src="" alt="">
             <div>
                <span>职称：</span>
                <span>经验：</span>
                <span>简介：</span>
             </div>
           </dd>
         </dl>
       </section>
  </div>
</template>

<script>
export default {
  data() {
    return {
      hospital: ""
    };
  },
  mounted() {},
  methods: {
    getHospitalName() {}
  }
};
</script>


<style scoped lang="less">
@import "../assets/index.less";
.hospital-detail {
  height: 100%;
}
.hospital-detail h1 {
  font-size: 16px;
  font-weight: normal;
}
.hospital-detail h2 {
  font-size: 14px;
  font-weight: normal;
}
.hospital-detail img {
  display: block;
  height: 8rem;
}
.hospital-detail section {
  display: block;
  min-height: 1rem;
  margin-bottom: 8px;
  background: #fff;
  padding: 8px;
  line-height: 30px;
}

.hospital-detail .hospital-detail-header h1,
.hospital-detail .hospital-detail-header dl {
  text-align: left;
}
.hospital-detail .hospital-detail-baseinfo h2,
.hospital-detail .hospital-detail-baseinfo dl {
  width: 100%;
  display: block;
  text-align: left;
}
.hospital-detail .hospital-detail-doctor h2 {
  text-align: left;
}

.hospital-detail .hospital-detail-doctor dd {
  display: flex;
  flex-direction: row;
  border-bottom:1px #f0f0f0 dashed;
  margin-bottom:10px;
}
.hospital-detail .hospital-detail-doctor dd img {
  width: 50px;
  height: 50px;
  border-radius: 25px;
  border: 1px #f00 solid;
  display: flex;
  margin-top: 15px;
}
.hospital-detail .hospital-detail-doctor dd span,.hospital-detail .hospital-detail-doctor dd div {
  display: flex;
}
.hospital-detail .hospital-detail-doctor dd div {
  flex-direction: column;
  margin-left: 15px;
}
</style>

