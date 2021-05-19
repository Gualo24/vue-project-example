<template>
  <div>
    <b-container>
      <b-breadcrumb :items="bc_items"></b-breadcrumb>
      <hr />
      <b-button variant="outline-primary" @click="goCreatePermission"
        >Crear Permiso</b-button
      >
      <b-table hover :items="items" :fields="fields">
        <template #cell(actions)="row">
          <b-button
            variant="outline-primary"
            size="sm"
            @click="info(row.item, row.index, $event.target)"
            class="mr-1"
          >
            Editar
          </b-button>
          <b-button
            size="sm"
            variant="outline-danger"
            @click="showAlert(row.item)"
          >
            Elimar
          </b-button>
        </template>
      </b-table>
    </b-container>
  </div>
</template>

<script>
import Moment from "moment";
import {
  ProvidersPermissionGetAll,
  ProvidersPermissionDelete
} from "../providers/permission_providers.js";

export default {
  data() {
    return {
      fields: [
        { key: "employeeNames", label: "Nombres" },
        { key: "employeeLastName", label: "Apellidos" },
        { key: "type.description", label: "Tipo Permiso" },
        {
          key: "permissionDate",
          label: "Fecha Permiso",
          formatter: (value, key, item) => {
            return Moment(value).format("DD/MM/yyyy");
          }
        },
        { key: "actions", label: "Acciones" }
      ],
      items: [],
      errors: [],
      bc_items: [
        {
          text: "Home",
          href: "#"
        },
        {
          text: "Listar Permisos",
          active: true
        }
      ]
    };
  },

  methods: {
    goCreatePermission() {
      this.$router.push(`/create`);
    },
    info(item) {
      this.$router.push(`/update/${item.id}`);
    },
    async showAlert(item) {
      // Use sweetalert2
      this.$swal({
        title:
          "Esta apunto de eliminar este permiso ¿Quiere continuar con esta acción?",
        showCancelButton: true,
        confirmButtonText: `Eliminar`,
        denyButtonText: `Don't save`
      }).then(result => {
        if (result.isConfirmed) {
          this.deletePermission(item.id);
        }
      });
    },
    async deletePermission(id) {
      const rst = await ProvidersPermissionDelete(id);
      if (rst.isSuccess) {
        await this.getPermission();
      } else {
      }
    },
    async getPermission() {
      const rst = await ProvidersPermissionGetAll();
      if (rst.isSuccess) {
        this.items = rst.result;
      } else {
      }
    }
  },

  async created() {
    await this.getPermission();
  }
};
</script>
