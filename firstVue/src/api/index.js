
//用户登录注册：根据openId 如果用户已经存在则返回用户信息，反之保存用户信息
export const DO_LOGIN='/api/users/?open_id=';
export const REGISTER='/api/users/save';
export const NEWS='/api/news';
export const WEIXIN_AUTH='/api/weixin/Auth';
//业绩查询
//api/order/performances/openid
export const USER_PERFOMANCES="/api/order/performances/"

//客户列表
//api/users/children／openid
export const USER_CLIENTS="/api/users/children/?openId="

export const PRODUCT_CAT="/api/productcat";
export const PRODUCT_LIST="/api/productlist/";

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
export const NEWS_DETAIL="api/articles/{0}"




export const USER_INFO="/api/user-info";
export const USER_POINTS="/api/user-mypoints";
export const USER_SUBSCRIBERS="/api/user-mysubscribers";




export const DICT_CATELOG="/api/catalogs.json"
export const DICT_CATELOG_ARTICLE="/api/articles"



export const HOSPITAL_LIST="/api/hospitals"
export const HOSPITAL_DETAIL="/api/hospital-detail/"





