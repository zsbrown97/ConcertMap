interface Venue {
    id: number;
    name: string;
    previous_names?: string;
    city: string;
    state: string;
    latitude: number;
    longitude: number;

}

const API_URL = "http://localhost:5187/api/Venue";

export async function getAllVenues(fetch: typeof window.fetch) {
    const res = await fetch(`${API_URL}`);
    return res.json();
}

export async function getVenues(): Promise<Venue> {
    const res = (await fetch(`${API_URL}`)).json();
    return res;
}