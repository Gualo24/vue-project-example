import { apiGet } from "./base_providers";

const controller = "PermissionType";

async function ProvidersPermissionTypeGetAll() {
  return await apiGet({
    controller: `v1/${controller}`
  });
}

export { ProvidersPermissionTypeGetAll };
