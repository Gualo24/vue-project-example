import { apiGet, apiPost, apiPut, apiDelete } from "./base_providers";

const controller = "Permission";

async function ProvidersPermissionGetAll() {
  return await apiGet({
    controller: `v1/${controller}`
  });
}

async function ProvidersPermissionGet(id) {
  return await apiGet({
    controller: `v1/${controller}/${id}`
  });
}

async function ProvidersPermissionDelete(id) {
  return await apiDelete({
    controller: `v1/${controller}`,
    id: id
  });
}

async function ProvidersPermissionCreate(permission) {
  return await apiPost({
    controller: `v1/${controller}`,
    data: permission
  });
}

async function ProvidersPermissionUpdate(permission) {
  return await apiPut({
    controller: `v1/${controller}`,
    data: permission
  });
}

export {
  ProvidersPermissionGetAll,
  ProvidersPermissionGet,
  ProvidersPermissionDelete,
  ProvidersPermissionCreate,
  ProvidersPermissionUpdate
};
