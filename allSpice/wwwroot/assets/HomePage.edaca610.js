import{_ as g,r as C,d as R,w as y,b as u,R as w,e as F,c as a,a as t,f as k,F as _,g as x,h as r,i as A,j as l,P as m,k as d,o as i,A as c,p as S,l as I}from"./index.1bf9c0b4.js";const G={setup(){const s=C(0);async function o(){try{await l.GetAllRecipes()}catch(e){m.error(e,"[getting alll recipes]")}}async function p(){try{await l.GetFavorites(),await l.SetFavorites()}catch(e){m.error(e,"[getting alll recipes]")}}return R(()=>{o()}),y(()=>{var e;(e=c.account)!=null&&e.id&&p()}),{recipes:u(()=>s.value?s.value==1?c.recipes.filter(e=>e.creatorId==c.account.id):c.recipes.filter(e=>e.favoriteId!=0):c.recipes),account:u(()=>c.account),async ChangeRecipes(e){s.value=e}}},components:{RecipeCard:w,RecipeForm:F}},v=s=>(S("data-v-cc0983b7"),s=s(),I(),s),M={class:"container mt-2"},P=v(()=>t("div",{class:"row rounded header-background py-5"},[t("div",{class:"col-12 text-center text-light"},[t("h1",null,"All-Spice"),t("h2",null,"Cherish Your Family"),t("h2",null,"And Their Cooking")])],-1)),B={class:"row"},H={class:"col-md-5 rounded sort-buttons m-auto p-3 d-flex justify-content-between bg-light"},N={class:"container"},V={class:"row"},j={class:"col-md-3 my-3 position-relative d-flex size"},E=v(()=>t("div",{class:"row sticky-bottom p-3"},[t("div",{class:"col-12 text-end"},[t("button",{class:"btn btn-success mdi mdi-plus",title:"Add Recipe","data-bs-toggle":"modal","data-bs-target":"#recipeForm"})])],-1));function $(s,o,p,e,z,L){const b=d("RecipeCard"),f=d("RecipeForm"),h=d("Modal");return i(),a(_,null,[t("div",M,[P,t("div",B,[t("div",H,[t("button",{class:"btn btn-outline-success",onClick:o[0]||(o[0]=n=>e.ChangeRecipes(0))},"Home"),t("button",{class:"btn btn-outline-success",onClick:o[1]||(o[1]=n=>e.ChangeRecipes(1))},"My Recipes"),e.account.id?(i(),a("button",{key:0,class:"btn btn-outline-success",onClick:o[2]||(o[2]=n=>e.ChangeRecipes(2))},"Favorites")):k("",!0)])])]),t("div",N,[t("div",V,[(i(!0),a(_,null,x(e.recipes,n=>(i(),a("div",j,[r(b,{recipe:n},null,8,["recipe"])]))),256))]),E]),r(h,{id:"recipeForm"},{default:A(()=>[r(f)]),_:1})],64)}const Y=g(G,[["render",$],["__scopeId","data-v-cc0983b7"]]);export{Y as default};
