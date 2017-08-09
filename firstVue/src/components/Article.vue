<template>
    <div class="vtitle" v-title="pageTitle">
        <section>
            <h1>关联百科</h1>
            <dl class='releated'>
                <dd v-for="item in detail.Related.content" :key="item.name">{{item.name}}</dd>
            </dl>
        </section>
    
        <section>
            <h1>简介</h1>
            <article v-html="detail.ShorDesc.content"></article>
        </section>
    
        <section>
            <h1>档案</h1>
          
             <ul v-html="propertyFormat(detail.Property.content)"></ul> 
        </section>
    
        <section>
            <h1>项目／手术原理</h1>
            <article v-html="detail.Desc.content"></article>
        </section>
    
        <section>
            <h1>效果示例</h1>
            <article v-html="detail.Sample.content"></article>
        </section>
        <section>
            <h1>优点</h1>
            <article v-html="detail.GoodPoint.content"></article>
        </section>
        <section>
            <h1>缺点及风险</h1>
            <article v-html="detail.BadPoint.content"></article>
        </section>
        <section>
            <h1>术前锦囊</h1>
            <article v-html="detail.BeforIdear.content"></article>
        </section>
        <section>
            <h1>术后锦囊</h1>
            <article v-html="detail.AfterIdear.content"></article>
        </section>
    </div>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
    computed: {
        ...mapGetters({
            detail: 'articleDetail'
        }),
        pageTitle: function () {

            let _name = this.$route.query.name
            return _name || '画眉鸟美容'
        }
    },
    beforeCreate() {
        let id = this.$route.query.id
        this.$store.dispatch('getArticleDetail', id)
    },
    mounted() {
        console.log(JSON.stringify(this.detail))
    },
    methods:{
        propertyFormat(content){
            
            if(!content) return '';
            content = content[0].replace(/^\\n/,'')
            return content
        }
    }
}
</script>


<style>
.vtitle h1 {
    font-weight: normal;
    font-size: 14px;
    color: #666;
    text-align: left;
}

.vtitle section {
    background: #fff;
    padding: 5px;
    box-sizing: border-box;
    margin-bottom: 10px;
    text-align: left;
    color:#9a9595;
    line-height: 22px;
}
.vtitle section p{
    margin:8px 0px;
}

section .releated dd {
    display: inline-block;
    border-radius: 3px;
    background: #f0f0f0;
    color: #666;
    padding: 5px 8px;
    margin-right: 10px;
    margin:8px;
}

section .releated li{
    list-style: none;
}
section  img{
    width:100% !important;
}
</style>

