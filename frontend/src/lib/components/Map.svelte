<script lang="ts">
    import { onMount } from 'svelte';
    import { getAllVenues } from '$lib/api/venues';

    let mapContainer: HTMLDivElement;

    let venues: any[] = [];

    onMount(async () => {
        const [venueData] = await Promise.all([
            getAllVenues(fetch)
        ]);
        venues = venueData;
   
        const L = await import('leaflet');
        const map = L.map(mapContainer);

        let bounds = L.latLngBounds([])

        L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
	        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>'
        }).addTo(map)

        venues.forEach((v) => {
            L.marker([v.latitude, v.longitude])
                .bindPopup(v.name)
                .addTo(map);
            bounds.extend([v.latitude, v.longitude])
        })

        map.fitBounds(bounds)
    });

</script>

<div bind:this={mapContainer}
    class="
        border
        border-gray-300
        h-[90vh]
        rounded-2xl
        shadow-md
        w-[50vw] 
    "
>
</div>