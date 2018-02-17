//用户登录
export const DO_ADMIN_LOGIN="";

//客户预约
export const GET_ORDERS="";

//业务员
export const GET_SALES="";
//业务员申请
export const GET_SALES_APPLY="";



//美容项目分类列表
export const GET_PROJECT_CAT_LIST="api2/project/getProjectCatbyparentid";


//美容项目
export const GET_PROJECT="api2/Project/getprojectdetail";
//删除美容项目
export const DELETE_PROJECT="api/Project/delete/{0}";
//美容项目列表
export const GET_PROJECT_LIST="api2/project/getprojectdetail";



//美容产品分类
export const GET_PRODUCT_CAT="api/ProductCat/{0}";
//美容从产品分类列表
export const GET_PRODUCT_CAT_LIST="api/ProductCat";
//删除美容产品分类
export const DELETE_PRODUCT_CAT="api/productcat/delete/{0}";
//美容产品
export const GET_PRODUCT="api/product/{0}";
//删除美容产品
export const DELETE_PRODUCT="api/product/delete/{0}";
//美容产品列表
export const GET_PRODUCT_LIST="api/productlist";




//--客户预约开始--------------------------------------------------------------

//获取客户预约
export const GET_SUBSCRIBERS="api2/order/getsubscribers"

//受理客户预约
export const ACCEPT_SUBSCRIBERS="api2/order/acceptsubscribers"

//拒绝客户预约
export const REFUSE_SUBSCRIBERS="api2/order/refusesubscribers"

//取消客户预约
export const CANCEL_SUBSCRIBERS="api2/order/cancelsubscribers"

//--客户预约结束--------------------------------------------------------------