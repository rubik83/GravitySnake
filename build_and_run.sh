#!/bin/env bash

set -xe

dotnet build -t:Run -f net6.0-android /p:AndroidSdkDirectory=/home/francois/Android/Sdk/
