import axios from "axios";
import Response from "../models/Response";

const URL_API = "https://localhost:5001/api/";

async function apiGet({ controller }) {
  try {
    const rst = await axios.get(`${URL_API}${controller}`, {
      headers: {
        "Content-Type": "application/json"
      }
    });
    if (rst.status == 200 || rst.status == 201 || rst.status == 204) {
      return new Response(true, null, rst.data);
    } else {
      return new Response(false, rst.data, null);
    }
  } catch (error) {
    return new Response(false, error.response.data, null);
  }
}

async function apiPost({ controller, data }) {
  const configuration = {
    headers: {
      "Content-Type": "application/json"
    }
  };
  try {
    const rst = await axios.post(
      `${URL_API}${controller}`,
      data,
      configuration
    );

    if (rst.status == 200 || rst.status == 201 || rst.status == 204) {
      return new Response(true, null, rst.data);
    } else {
      return new Response(false, rst.data, null);
    }
  } catch (error) {
    return new Response(false, error.response.data, null);
  }
}

async function apiPut({ controller, data }) {
  const configuration = {
    headers: {
      "Content-Type": "application/json"
    }
  };
  try {
    const rst = await axios.put(`${URL_API}${controller}`, data, configuration);

    if (rst.status == 200 || rst.status == 201 || rst.status == 204) {
      return new Response(true, null, rst.data);
    } else {
      return new Response(false, rst.data, null);
    }
  } catch (error) {
    return new Response(false, error.response.data, null);
  }
}

async function apiDelete({ controller, id }) {
  const configuration = {
    headers: {
      "Content-Type": "application/json"
    }
  };
  try {
    const rst = await axios.delete(
      `${URL_API}${controller}/?id=${id}`,
      configuration
    );

    if (rst.status == 200 || rst.status == 201 || rst.status == 204) {
      return new Response(true, null, rst.data);
    } else {
      return new Response(false, rst.data, null);
    }
  } catch (error) {
    return new Response(false, error.response.data, null);
  }
}

export { apiGet, apiPost, apiPut, apiDelete };
