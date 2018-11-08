
//用户登录注册：根据openId 如果用户已经存在则返回用户信息，反之保存用户信息
export const DO_LOGIN='/api/users/?open_id=';
export const REGISTER='/api/users/save';
export const NEWS='/api/news';
export const WEIXIN_AUTH='/api/weixin/Auth';
export const GET_BASE_INFO='/api/infos/{infoId}'
//业绩查询
//api/order/performances/openid
export const USER_PERFOMANCES="/api/order/performances/"

//获取用户升级信息
export const USER_GET_UPGRADEINFO="/api/users/upgrade/{openId}/info"
//用户升级
export const USER_DO_UPGRADE="/api/users/upgrade/{openId}/"

//客户列表
//api/users/children／openid
export const USER_CLIENTS="/api/users/children/?openId="

//护肤美容产品分类
export const PRODUCT_CAT="/api/products/types";
// 护肤美容产品列表
export const PRODUCT_LIST="/api/products/list/{0}";
export const PRODUCT_LIST_BYCAT="/api/products/list/{0}";
//护肤美容产品详情
export const PRODUCT_DETAIL="/api/products/{0}";
//订单列表
export const PRODUCT_ORDER_LIST="/api/product_order/list?userId={0}&pageNo={1}"

//兑换产品
export const EXCHANGE_PRODUCT_SAVE="/api/product_order/save"
//根据用户查看兑换产品激励
export const GET_USER_EXCHANGE_INFO="/api/product_order/list"

//获取微信用户信息
export const GET_WX_INFO="/api/users/wx/"
//获取初始化微信JSSDK信息
export const GET_INIT_JSSDK_INFO='/api/users/wx/signature'

//美容项目分类
export const PROJECT_CAT="/api/categories";
//美容项目列表
export const PROJECT_LIST="/api/projects/list/category/";
//详情接口
export const PROJECT_DETAIL="/api/projects/";
//提交预约
export const SUBMIT_ORDER='/api/order/save'

//查新订单
export const QUERY_ORDERS="/api/order/";
//查询预约

//资讯文章查询-文章列表
export const NEWS_LIST="/api/articles?pageNo={0}&pageSize={1}"
//资讯文章查询-文章详情
export const NEWS_DETAIL="/api/articles/{0}"




export const USER_INFO="/api/user-info";
export const USER_POINTS="/api/user-mypoints";
export const USER_SUBSCRIBERS="/api/user-mysubscribers";




export const DICT_CATELOG="/api/catalogs.json"
export const DICT_CATELOG_ARTICLE="/api/articles"



export const HOSPITAL_LIST="/api/hospitals"
export const HOSPITAL_DETAIL="/api/hospital-detail/"


//获取页面广告位图片
export const ADVERTISMENT="/api/advertisment/get_adv_list"

//保存用户分享海报信息
export const SAVE_USER_SHARE_PLACARD_INFO='/api/share/save'
//获取用户分享海报信息
export const GET_USER_SHALE_INFO='/api/share/{0}'




