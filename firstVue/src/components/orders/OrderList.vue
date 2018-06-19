<template>
    <div class="order-list">
        <dl>
            <dd v-for="item in data" :key="item.name">
                <router-link :to="{ path: '/projects-detail', query: { id: item.projectId }}">
                <div class="title">
                    订单号：{{item.orderNo}}
                </div>
                <div class="left">
                    <span>预约日期：{{item.subscribeDate}}</span>
                    <span>预约项目：{{item.projectName}}</span>
                </div>
                <div class="right">
                     <span>&nbsp;</span><br/>
                    <span>{{item.orderStatus}}</span>
                </div>
                </router-link>
            </dd>
        </dl>
    </div>
</template>

<script>
export default {
    props: {
        data:null
    }
}
</script>

<style scoped lang="less">
@import '../../assets/index.less';
.order-list {
    width: 100%;
    background: #fff;
    padding-bottom:3rem;
}


.order-list dd {
   width: 95%;
    border: 1px #f2f2f2 solid;
    background: #f2f2f2;
    margin: auto;
    margin-top: 0.5rem;
    border-radius: 5px;
    height: 4rem;
   overflow: hidden;
}
.order-list dd a{
 text-decoration: none;
    color: #666;
}

.order-list dd .title{
    height: 1.2rem;
    background: #eae9ea;
    text-align: left;
    line-height: 1.2rem;
    text-indent: 0.5rem;
}


.order-list dd .left,
.order-list dd .right {
    display: block;
    float: left;
    height: auto;
    line-height: 25px;
}

.order-list dd .left {
    width: 80%;
    text-align: left;
    padding-top: 0.4rem;
    padding-left: 0.5rem;
}
.order-list dd .left span{
    display: block;
    height: 1rem;
    line-height: 1rem;
}

.order-list dd .right {
    width: 20%;
    color: @font-hot-color ;
    text-align: right;
    padding-right: 8px;
}
</style>

