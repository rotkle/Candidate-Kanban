import { environment } from "src/environments/environment";

const host = environment.apiUrl;
const apiApp = host + '/api'

export const ApiPaths = {
    candidates: `${apiApp}/candidates`,
    jobs: `${apiApp}/jobs`,
    status: `${apiApp}/status`,
}