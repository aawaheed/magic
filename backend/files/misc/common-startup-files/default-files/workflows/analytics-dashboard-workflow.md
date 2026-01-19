# Workflow; Create Analytics Dashboard
WORKFLOW ==> analytics-dashboard-workflow

## Purpose
Provide a guided process for building interactive analytics dashboards that visualise data from databases or APIs.

## Steps

1. Ask the user which data source to use (database or API).
   - If the user has his own CSV file here, it can be uploaded in SQL Studio
2. Retrieve the schema or data structure to understand available metrics.
3. Let the user choose chart types (bar, line, pie, table, etc.).
4. Generate HTML widgets using Chart.js or Mermaid for visualisation.
5. Combine widgets into a responsive dashboard layout.
6. Save the dashboard inside the /etc/www/ folder as a SPA webpage.

## Outcome

A reusable analytics dashboard that displays key metrics in real time, with export and sharing options.
