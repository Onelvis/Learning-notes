# Data dog

learn.datadoghq.com

## Data collection is done by:
* Agents
* Connection to AWS account (Cloud watch)
* Tracing agent (python module, C# packages, etc)

## Dashboards
* `preset` ones are the one created by default by datadog


Monitor != Dashboards

To monitor a service, create a monitor

```yaml
process-monitor:
	enabled: yes
```