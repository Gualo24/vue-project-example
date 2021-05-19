import Vue from "vue";
import Router from "vue-router";
import HelloWorld from "@/components/HelloWorld";
import CreatePermission from "@/components/createPermission";
import UpdatePermission from "@/components/editPermission";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "HelloWorld",
      component: HelloWorld
    },
    {
      path: "/create",
      name: "Create Permission",
      component: CreatePermission
    },
    {
      path: "/update/:id",
      name: "Update Permission",
      component: UpdatePermission
    }
  ]
});
