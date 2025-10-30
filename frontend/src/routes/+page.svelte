<script lang="ts">
    import Map from "$lib/components/Map.svelte";
    import ConcertTable from "$lib/components/ConcertTable/ConcertTable.svelte";

</script>

<div class="p-6 space-y-4">
    <h1 class="text-3xl font-bold underline">Concert Map</h1>
    <Map />
    <ConcertTable />
</div>

<style lang="postcss">
    @reference "tailwindcss";

    :global(html) {
        background-color: theme(--color-gray-100);
    }
</style>