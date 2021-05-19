<template>
  <div>
    <b-container>
      <b-breadcrumb :items="bc_items"></b-breadcrumb>
      <hr />
      <b-button variant="outline-primary" @click="goBack"
        >Volver atras</b-button
      >
      <b-card title="Crear nuevo permiso">
        <b-form v-on:submit.prevent="addPermission">
          <b-form-group>
            <label for="cbo-permission-type"
              >Seleccionar el tipo de permiso</label
            >
            <br />
            <b-form-select
              id="cbo-permission-type"
              v-model="permission.permissionType"
              :options="permissionTypes"
            ></b-form-select>
          </b-form-group>
          <b-form-group
            id="input-group-1"
            label="Nombres del empleado:"
            label-for="input-1"
          >
            <b-form-input
              id="input-1"
              v-model="permission.employeeNames"
              type="text"
              required
            ></b-form-input>
          </b-form-group>

          <b-form-group
            id="input-group-1"
            label="Apellidos del empleado:"
            label-for="input-1"
          >
            <b-form-input
              id="input-1"
              v-model="permission.employeeLastName"
              type="text"
              required
            ></b-form-input>
          </b-form-group>
          <b-form-group>
            <label for="example-datepicker"
              >Seleccione la fecha del permiso</label
            >
            <b-form-datepicker
              id="example-datepicker"
              v-model="permission.permissionDate"
              class="mb-2"
            ></b-form-datepicker
          ></b-form-group>
          <b-button type="submit" variant="primary">Guardar</b-button>
        </b-form>
      </b-card>
      <div v-if="isValid">
        <b-alert show variant="danger"
          ><ul>
            <li v-for="error in validateError">
              {{ error }}
            </li>
          </ul></b-alert
        >
      </div>
    </b-container>
  </div>
</template>

<script>
import axios from "axios";
import { ProvidersPermissionTypeGetAll } from "../providers/permissionType_providers.js";
import {
  ProvidersPermissionGet,
  ProvidersPermissionCreate
} from "../providers/permission_providers.js";

export default {
  data() {
    return {
      validateError: [],
      permissionTypes: [],
      permission: {
        employeeNames: "",
        employeeLastName: "",
        permissionType: null,
        permissionDate: null
      },
      bc_items: [
        {
          text: "Home",
          href: "#"
        },
        {
          text: "Crear Permiso",
          active: true
        }
      ]
    };
  },

  methods: {
    goBack() {
      this.$router.back();
    },
    async getPermissionTypes() {
      const rst = await ProvidersPermissionTypeGetAll();
      if (rst.isSuccess) {
        rst.result.forEach(e => {
          this.permissionTypes.push({ value: e.id, text: e.description });
        });
      } else {
      }
    },

    async savePermission() {
      const rst = await ProvidersPermissionCreate(this.permission);
      if (rst.isSuccess) {
        this.goBack();
      } else {
        console.log(rst.message);
      }
    },

    addPermission() {
      this.validateError = [];
      let bien = true;
      if (
        !this.permission.employeeNames ||
        this.permission.employeeNames.length == 0
      ) {
        bien = false;
        this.validateError.push("Coloque el nombre del empleado");
      }

      if (
        !this.permission.employeeLastName ||
        this.permission.employeeLastName.length == 0
      ) {
        bien = false;
        this.validateError.push("Coloque el apellido del empleado");
      }

      if (
        !this.permission.permissionType ||
        this.permission.permissionType.length == 0
      ) {
        bien = false;
        this.validateError.push("Coloque el tipo de permiso");
      }

      if (
        !this.permission.permissionDate ||
        this.permission.permissionDate.length == 0
      ) {
        bien = false;
        this.validateError.push("Coloque la fecha del permiso");
      }

      if (bien) {
        this.savePermission();
      }
    }
  },

  computed: {
    isValid() {
      return this.validateError.length == 0 ? false : true;
    }
  },
  async created() {
    await this.getPermissionTypes();
  }
};
</script>
