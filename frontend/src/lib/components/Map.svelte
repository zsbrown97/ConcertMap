<script lang="ts">
    import { onMount } from 'svelte';
    import { getAllVenues } from '$lib/api/venues';
    import 'leaflet.markercluster/dist/MarkerCluster.css';
    import 'leaflet.markercluster/dist/MarkerCluster.Default.css';

    let mapContainer: HTMLDivElement;

    let venues: any[] = [];

    onMount(async () => {
        const [venueData] = await Promise.all([
            getAllVenues(fetch)
        ]);
        venues = venueData;

        const L = await import('leaflet');
        (window as any).L = L;
        await import('leaflet.markercluster');
        const map = L.map(mapContainer);

        let bounds = L.latLngBounds([])

        L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
	        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>'
        }).addTo(map)

        const clusterGroup = L.markerClusterGroup();

        venues.forEach((v) => {
            L.marker([v.latitude, v.longitude])
                .bindPopup(v.name)
                .addTo(clusterGroup);
            bounds.extend([v.latitude, v.longitude])
        })

        map.addLayer(clusterGroup);
        map.fitBounds(bounds);
    });

</script>

<div bind:this={mapContainer}
    class="
        border
        border-gray-300
        h-[50vh]
        rounded-2xl
        shadow-md
        w-full 
    "
>
</div>